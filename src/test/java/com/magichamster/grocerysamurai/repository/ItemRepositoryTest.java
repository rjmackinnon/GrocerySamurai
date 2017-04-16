package com.magichamster.grocerysamurai.repository;

import com.magichamster.grocerysamurai.model.Item;

/**
 * Test specifically for Item
 * Created by Rick on 4/15/17.
 */
public class ItemRepositoryTest extends IBaseRepositoryTest<Item> {
    @Override
    public IBaseRepository<Item> getRepository() {
        return new BaseRepository<>(Item.class, "grocery");
    }

    @Override
    public Item createEntity(int id) {
        Item entity = new Item();
        entity.setId(id);
        entity.setName("entity" + id);
        return entity;
    }
}
