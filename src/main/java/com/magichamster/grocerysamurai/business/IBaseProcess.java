package com.magichamster.grocerysamurai.business;

import java.util.*;

import com.magichamster.grocerysamurai.model.Identity;

public interface IBaseProcess<T extends Identity> {
	void persist(T entity);

	void persist(Collection<T> entities);

	void persist(T... entities);
	
	void merge(T entity);
	
	void merge(Collection<T> entities);
	
	void merge(T... entities);

	void remove(T entity);

	void remove(Collection<T> entities);

	void remove(T... entities);

	void remove(int id);

	Set<T> get();

	Optional<T> get(int id);
}
