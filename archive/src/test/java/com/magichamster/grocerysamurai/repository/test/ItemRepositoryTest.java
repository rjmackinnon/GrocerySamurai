package com.magichamster.grocerysamurai.repository.test;

import com.magichamster.grocerysamurai.model.Item;

import javax.persistence.Persistence;
import com.magichamster.grocerysamurai.repository.BaseRepository;
import com.magichamster.grocerysamurai.repository.IBaseRepository;

/**
 * Test specifically for Item Created by Rick on 4/15/17.
 */
public class ItemRepositoryTest extends IBaseRepositoryTest<Item> {
	@Override
	public IBaseRepository<Item> getRepository() {
		return new BaseRepository<>(Item.class, Persistence.createEntityManagerFactory("grocery"));
	}

	@Override
	public Item createEntity(int id) {
		Item entity = new Item();
		entity.setName("Item" + id);
		return entity;
	}
}
