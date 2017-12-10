package com.magichamster.grocerysamurai.repository;

import com.magichamster.grocerysamurai.model.Identity;

import java.util.Arrays;
import java.util.Collection;
import java.util.Optional;
import java.util.Set;
import java.util.function.Predicate;
import java.util.stream.Collectors;

/**
 * Base interface for repositories Created by Rick on 4/13/17.
 */
public interface IBaseRepository<T extends Identity> {
	void persist(T entity);

	default void persist(Collection<T> entities) {
		entities.forEach(this::persist);
	}

	default void persist(T... entities) {
		persist(Arrays.asList(entities));
	}
	
	void merge(T entity);
	
	default void merge(Collection<T> entities) {
		entities.forEach(this::merge);
	}
	
	default void merge(T... entities) {
		merge(Arrays.asList(entities));
	}

	void remove(T entity);

	default void remove(Collection<T> entities) {
		entities.forEach(this::remove);
	}

	default void remove(T... entities) {
		remove(Arrays.asList(entities));
	}

	default void remove(int id) {
		remove(e -> e.getId() == id);
	}

	default void remove(Predicate<T> predicate) {
		get(predicate).forEach(this::remove);
	}

	Set<T> get();

	default Optional<T> get(int id) {
		return get().stream().filter(e -> e.getId() == id).findAny();
	}

	default Set<T> get(Predicate<T> predicate) {
		return get().stream().filter(predicate).collect(Collectors.toSet());
	}

	void runNamedStoredProcedure(String name);
}
