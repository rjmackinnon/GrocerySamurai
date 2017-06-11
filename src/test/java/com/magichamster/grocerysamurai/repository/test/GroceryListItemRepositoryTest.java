package com.magichamster.grocerysamurai.repository.test;

import com.magichamster.grocerysamurai.model.GroceryList;
import com.magichamster.grocerysamurai.model.GroceryListItem;
import com.magichamster.grocerysamurai.model.Item;
import com.magichamster.grocerysamurai.model.Store;
import com.magichamster.grocerysamurai.repository.BaseRepository;
import com.magichamster.grocerysamurai.repository.IBaseRepository;

import javax.persistence.Persistence;

/**
 * Test specifically for GroceryListItem Created by Rick on 4/15/17.
 */
public class GroceryListItemRepositoryTest extends IBaseRepositoryTest<GroceryListItem> {
	@Override
	public IBaseRepository<GroceryListItem> getRepository() {
		return new BaseRepository<>(GroceryListItem.class, Persistence.createEntityManagerFactory("grocery"));
	}

	@Override
	public GroceryListItem createEntity(int id) {
		Store store = new Store();
		store.setName("Store" + id);

		GroceryList groceryList = new GroceryList();
		groceryList.setName("GroceryList" + id);
		groceryList.setStore(store);

		Item item = new Item();
		item.setName("Item" + id);

		GroceryListItem entity = new GroceryListItem();
		entity.setGroceryList(groceryList);
		entity.setItem(item);
		entity.setQuantity(1);
		return entity;
	}
}
