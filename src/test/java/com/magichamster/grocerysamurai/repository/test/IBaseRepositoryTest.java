package com.magichamster.grocerysamurai.repository.test;

import com.magichamster.grocerysamurai.model.Identity;
import com.magichamster.grocerysamurai.repository.IBaseRepository;

import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.Set;

import static org.assertj.core.api.Assertions.assertThat;

/**
 * Abstract class for testing repository methods Created by Rick on 4/14/17.
 */
public abstract class IBaseRepositoryTest<T extends Identity> {
	private static long startTime;
	protected IBaseRepository<T> repository;
	protected T entity1;
	protected T entity2;
	protected T entity3;

	@BeforeClass
	public static void startBenchmark() throws Exception {
		startTime = System.currentTimeMillis();
	}

	@AfterClass
	public static void stopBenchmark() throws Exception {
		final long endTime = System.currentTimeMillis();
		final long diff = endTime - startTime;

		System.out.println("Millis spent: " + diff);
	}

	public abstract IBaseRepository<T> getRepository();

	public abstract T createEntity(int id);

	@Before
	public void setup() {
		// Arrange
		repository = getRepository();

		repository.runNamedStoredProcedure("ClearTest");

		entity1 = createEntity(1);
		entity2 = createEntity(2);
		entity3 = createEntity(3);
	}

	@Test
	public void testPersistOneEntity() throws Exception {
		// Act
		repository.persist(entity1);

		// Assert
		assertThat(repository.get()).contains(entity1);
	}

	@Test
	public void testPersistWithVarargs() throws Exception {
		// Act
		repository.persist(entity1, entity2);

		// Assert
		assertThat(repository.get()).containsOnly(entity1, entity2);
	}

	@Test
	public void testPersistWithList() throws Exception {
		// Arrange
		List<T> testList = new ArrayList<>();
		testList.add(entity1);
		testList.add(entity2);
		testList.add(entity3);

		// Act
		repository.persist(testList);
		assertThat(repository.get()).containsOnly(entity1, entity2, entity3);
	}

	@Test
	public void testRemoveOneEntity() throws Exception {
		// Arrange
		repository.persist(entity1, entity2, entity3);

		// Act
		repository.remove(entity1);

		// Assert
		assertThat(repository.get()).doesNotContain(entity1);
	}

	@Test
	public void testRemoveWithVarargs() throws Exception {
		// Arrange
		repository.persist(entity1, entity2);

		// Act
		repository.remove(entity1, entity2);

		// Assert
		assertThat(repository.get()).isEmpty();
	}

	@Test
	public void testRemoveWithList() throws Exception {
		// Arrange
		repository.persist(entity1, entity2, entity3);
		List<T> testList = new ArrayList<>();
		testList.add(entity3);

		// Act
		repository.remove(testList);

		// Assert
		assertThat(repository.get()).doesNotContain(entity3);
	}

	@Test
	public void testRemoveWithPredicate() throws Exception {
		// Arrange
		repository.persist(entity1, entity2, entity3);

		// Act
		repository.remove(e -> e.getId() == entity2.getId());

		// Assert
		assertThat(repository.get()).doesNotContain(entity2);
	}

	@Test
	public void testRemoveById() throws Exception {
		// Arrange
		repository.persist(entity1, entity2, entity3);

		// Act
		repository.remove(entity1.getId());

		// Assert
		assertThat(repository.get()).doesNotContain(entity1);
	}

	@Test
	public void testGet() throws Exception {
		// Arrange
		repository.persist(entity1, entity2, entity3);

		// Assert
		assertThat(repository.get()).contains(entity1, entity2, entity3);
	}

	@Test
	public void testGetWithOptional() throws Exception {
		// Arrange
		repository.persist(entity1, entity2, entity3);

		// Act
		final Optional<T> entityOptional = repository.get(entity2.getId());

		// Assert
		assertThat(entityOptional.isPresent()).isTrue();
		assertThat(entityOptional.get()).isEqualTo(entity2);
	}

	@Test
	public void testGetNotFound() throws Exception {
		// Arrange
		repository.persist(entity1, entity2, entity3);

		// Act
		final Optional<T> entityOptional = repository.get(-1);

		// Assert
		assertThat(entityOptional.isPresent()).isFalse();
	}

	@Test
	public void testGetWithSet() throws Exception {
		// Arrange
		repository.persist(entity1, entity2, entity3);

		// Act
		final Set<T> entitySet = repository.get(e -> e.getId() > 0);

		// Assert
		assertThat(entitySet).contains(entity1, entity2, entity3);
	}
}