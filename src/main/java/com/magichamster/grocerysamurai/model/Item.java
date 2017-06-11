package com.magichamster.grocerysamurai.model;

import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;

/**
 * Table of grocery items Created by Rick on 4/9/17.
 */
@NamedStoredProcedureQuery(name = "ClearTest", procedureName = "clear_test")
@Entity
@Table(name = "item")
public class Item extends Identity {
	@Column(name = "name", nullable = false)
	private String name;

	@Column(name = "description")
	private String description;

	@Column(name = "upc")
	private long Upc;

	@OneToMany(fetch = FetchType.LAZY, cascade = { CascadeType.ALL, CascadeType.PERSIST,
			CascadeType.MERGE }, mappedBy = "item")
	private Set<StoreItem> storeItems;

	@OneToMany(fetch = FetchType.LAZY, cascade = { CascadeType.ALL, CascadeType.PERSIST,
			CascadeType.MERGE }, mappedBy = "item")
	private Set<GroceryListItem> groceryListItems;

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public long getUpc() {
		return Upc;
	}

	public void setUpc(long upc) {
		Upc = upc;
	}

	public Item() {
		storeItems = new HashSet<>(0);
		groceryListItems = new HashSet<>(0);
	}

	public Set<StoreItem> getStoreItems() {
		return storeItems;
	}

	public void setStoreItems(Set<StoreItem> storeItems) {
		this.storeItems = storeItems;
	}

	public Set<GroceryListItem> getGroceryListItems() {
		return groceryListItems;
	}

	public void setGroceryListItems(Set<GroceryListItem> groceryListItems) {
		this.groceryListItems = groceryListItems;
	}
}
