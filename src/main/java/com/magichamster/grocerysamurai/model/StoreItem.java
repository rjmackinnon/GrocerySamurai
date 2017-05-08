package com.magichamster.grocerysamurai.model;

import javax.persistence.*;

/**
 * Allow for items on different aisles Created by developer on 4/14/17.
 */
@Entity
@Table(name = "store_item")
public class StoreItem extends Identity {
	@ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
	@JoinColumn(name = "store_id", nullable = false)
	private Store store;

	@ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
	@JoinColumn(name = "aisle_id", nullable = false)
	private Aisle aisle;

	@ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
	@JoinColumn(name = "item_id", nullable = false)
	private Item item;

	public StoreItem() {
	}

	public Store getStore() {
		return store;
	}

	public void setStore(Store store) {
		this.store = store;
		store.getStoreItems().add(this);
	}

	public Aisle getAisle() {
		return aisle;
	}

	public void setAisle(Aisle aisle) {
		this.aisle = aisle;
		aisle.getStoreItems().add(this);
	}

	public Item getItem() {
		return item;
	}

	public void setItem(Item item) {
		this.item = item;
		item.getStoreItems().add(this);
	}
}
