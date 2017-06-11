package com.magichamster.grocerysamurai.repository.test;

import com.magichamster.grocerysamurai.model.Store;
import com.magichamster.grocerysamurai.repository.BaseRepository;
import com.magichamster.grocerysamurai.repository.IBaseRepository;

import javax.persistence.Persistence;

/**
 * Test specifically for Store Created by Rick on 4/22/17.
 */
public class StoreRepositoryTest extends IBaseRepositoryTest<Store> {
	@Override
	public IBaseRepository<Store> getRepository() {
		return new BaseRepository<>(Store.class, Persistence.createEntityManagerFactory("grocery"));
	}

	@Override
	public Store createEntity(int id) {
		Store entity = new Store();
		entity.setName("Store" + id);
		return entity;
	}
}
