package com.magichamster.grocerysamurai.business;

import java.util.*;

import javax.persistence.Persistence;

import com.magichamster.grocerysamurai.model.*;
import com.magichamster.grocerysamurai.repository.BaseRepository;
import com.magichamster.grocerysamurai.repository.IBaseRepository;

public class ItemProcess extends BaseProcess<Item> {
	public ItemProcess(IBaseRepository<Item> repository) {
		super(repository == null ? new BaseRepository<Item>(Item.class, Persistence.createEntityManagerFactory("grocery")) :
			repository);
	}

	public List<Item> getSorted() {
		List<Item> list = new LinkedList<Item>(repository.get());
		list.sort((i1, i2) -> i1.getName().compareTo(i2.getName()));
		return list;
	}
}
