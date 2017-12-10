package com.magichamster.grocerysamurai.repository.test;

import com.magichamster.grocerysamurai.model.AppUser;
import com.magichamster.grocerysamurai.repository.BaseRepository;
import com.magichamster.grocerysamurai.repository.IBaseRepository;

import javax.persistence.Persistence;

/**
 * Test specifically for AppUser Created by Rick on 6/11/17.
 */
public class AppUserRepositoryTest extends IBaseRepositoryTest<AppUser> {
	@Override
	// TODO: Use mock EMF instead of DB
	public IBaseRepository<AppUser> getRepository() {
		return new BaseRepository<>(AppUser.class, Persistence.createEntityManagerFactory("grocery"));
	}

	@Override
	public AppUser createEntity(int id) {
		AppUser entity = new AppUser();
		entity.setUsername("AppUser" + id);
		entity.setFirstname("AppUser" + id);
		return entity;
	}
}
