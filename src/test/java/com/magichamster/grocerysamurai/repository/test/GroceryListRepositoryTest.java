package com.magichamster.grocerysamurai.repository.test;

import com.magichamster.grocerysamurai.model.GroceryList;
import com.magichamster.grocerysamurai.model.Store;

import javax.persistence.Persistence;
import com.magichamster.grocerysamurai.repository.BaseRepository;
import com.magichamster.grocerysamurai.repository.IBaseRepository;

/**
 * Test specifically for GroceryList Created by Rick on 4/22/17.
 */
public class GroceryListRepositoryTest extends IBaseRepositoryTest<GroceryList> {
	@Override
	public IBaseRepository<GroceryList> getRepository() {
		return new BaseRepository<>(GroceryList.class, Persistence.createEntityManagerFactory("grocery"));
	}

	@Override
	public GroceryList createEntity(int id) {
		Store store = new Store();
		store.setName("Store" + id);

		GroceryList entity = new GroceryList();
		entity.setName("GroceryList" + id);
		entity.setStore(store);
		return entity;
	}
}
