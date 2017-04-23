package com.magichamster.grocerysamurai.repository;

import com.magichamster.grocerysamurai.model.Aisle;
import com.magichamster.grocerysamurai.model.Item;
import com.magichamster.grocerysamurai.model.Store;
import com.magichamster.grocerysamurai.model.StoreItem;

import javax.persistence.Persistence;

/**
 * Test specifically for StoreItem
 * Created by Rick on 4/22/17.
 */
public class StoreItemRepositoryTest extends IBaseRepositoryTest<StoreItem> {
    @Override
    public IBaseRepository<StoreItem> getRepository() {
        return new BaseRepository<>(StoreItem.class, Persistence.createEntityManagerFactory("grocery"));
    }

    @Override
    public StoreItem createEntity(int id) {
        Store store = new Store();
        store.setName("Store" + id);

        Item item = new Item();
        item.setName("Item" + id);

        Aisle aisle = new Aisle();
        aisle.setName("Aisle" + id);

        StoreItem entity = new StoreItem();
        entity.setStore(store);
        entity.setItem(item);
        entity.setAisle(aisle);
        return entity;
    }
}
