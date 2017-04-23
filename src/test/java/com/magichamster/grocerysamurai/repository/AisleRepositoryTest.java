package com.magichamster.grocerysamurai.repository;

import com.magichamster.grocerysamurai.model.Aisle;

import javax.persistence.Persistence;

/**
 * Test specifically for Aisle
 * Created by Rick on 4/22/17.
 */
public class AisleRepositoryTest extends IBaseRepositoryTest<Aisle> {
    @Override
    public IBaseRepository<Aisle> getRepository() {
        return new BaseRepository<>(Aisle.class, Persistence.createEntityManagerFactory("grocery"));
    }

    @Override
    public Aisle createEntity(int id) {
        Aisle entity = new Aisle();
        entity.setName("Aisle" + id);
        return entity;
    }
}