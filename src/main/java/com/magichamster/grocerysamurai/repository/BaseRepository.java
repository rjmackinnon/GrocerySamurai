package com.magichamster.grocerysamurai.repository;

import com.magichamster.grocerysamurai.model.Identity;

import javax.persistence.*;
import javax.persistence.criteria.*;
import java.util.*;
import java.util.function.*;
import java.util.function.Predicate;

/**
 * Implementation of IBaseRepository for JPA
 * Created by Rick on 4/14/17.
 */
public class BaseRepository<T extends Identity> implements IBaseRepository<T> {
    private EntityManagerFactory emf;
    private Class<T> type;

    public BaseRepository(Class<T> type, String persistenceUnitName) {
        this.type = type;
        emf = Persistence.createEntityManagerFactory(persistenceUnitName);
    }

    @Override
    public Set<T> get() {
        List<T> resultList = run(entityManager -> {
            final CriteriaBuilder criteriaBuilder = entityManager.getCriteriaBuilder();
            final CriteriaQuery<T> criteria = criteriaBuilder.createQuery(type);

            final Root<T> root = criteria.from(type);
            criteria.select(root);

            final TypedQuery<T> query = entityManager.createQuery(criteria);
            return query.getResultList();
        });

        return new HashSet<>(resultList);
    }

    @Override
    public Optional<T> get(int id) {
        return Optional.ofNullable(run(entityManager -> {
            return entityManager.find(type, id);
        }));
    }

    @Override
    public void persist(T entity) {
        runInTransaction(entityManager -> {
            entityManager.merge(entity);
        });
    }

    @Override
    public void persist(Collection<T> entities) {
        runInTransaction(entityManager -> {
            entities.forEach(entityManager::merge);
        });
    }

    @Override
    public void remove(T entity) {
        runInTransaction(entityManager -> {
            final T managedEntity = entityManager.find(type, entity.getId());
            if (managedEntity != null) {
                entityManager.remove(managedEntity);
            }
        });
    }

    @Override
    public void remove(int id) {
        runInTransaction(entityManager -> {
           final T managedEntity = entityManager.find(type, id);
           if (managedEntity != null) {
               entityManager.remove(managedEntity);
           }
        });
    }

    @Override
    public void remove(Collection<T> entities) {
        runInTransaction(entityManager -> {
            entities
                    .stream()
                    .map(Identity::getId)
                    .map(id -> entityManager.find(type, id))
                    .filter(Objects::nonNull)
                    .forEach(entityManager::remove);
        });
    }

    @Override
    public void remove(Predicate<T> predicate) {
        remove(get(predicate));
    }

    private <R> R run(Function<EntityManager, R> function) {
        final EntityManager entityManager = emf.createEntityManager();
        try {
            return function.apply(entityManager);
        }
        finally {
            entityManager.close();
        }
    }

    private void run(Consumer<EntityManager> function) {
        run(entityManager -> {
           function.accept(entityManager);
           return null;
        });
    }

    private <R> R runInTransaction(Function<EntityManager, R> function) {
        return run(entityManager -> {
           entityManager.getTransaction().begin();

           final R result = function.apply(entityManager);

           entityManager.getTransaction().commit();

           return result;
        });
    }

    private void runInTransaction(Consumer<EntityManager> function) {
        runInTransaction(entityManager -> {
           function.accept(entityManager);
           return null;
        });
    }
}
