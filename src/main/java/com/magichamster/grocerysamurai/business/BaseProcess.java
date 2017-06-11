package com.magichamster.grocerysamurai.business;

import java.util.*;

import com.magichamster.grocerysamurai.model.Identity;
import com.magichamster.grocerysamurai.repository.IBaseRepository;

public class BaseProcess<T extends Identity> implements IBaseProcess<T> {
	protected IBaseRepository<T> repository;
	
	public BaseProcess(IBaseRepository<T> repository)
	{
		this.repository = repository;
	}
	
	@Override
	public void persist(T entity) {
		repository.persist(entity);
	}

	@Override
	public void persist(Collection<T> entities) {
		repository.persist(entities);
	}

	@Override
	public void persist(T... entities) {
		repository.persist(entities);
	}

	@Override
	public void remove(T entity) {
		repository.remove(entity);
	}

	@Override
	public void remove(Collection<T> entities) {
		repository.remove(entities);
	}

	@Override
	public void remove(T... entities) {
		repository.remove(entities);
	}

	@Override
	public void remove(int id) {
		repository.remove(id);
	}

	@Override
	public Set<T> get() {
		return repository.get();
	}

	@Override
	public Optional<T> get(int id) {
		return repository.get(id);
	}
}
