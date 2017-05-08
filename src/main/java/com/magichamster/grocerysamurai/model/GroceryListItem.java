package com.magichamster.grocerysamurai.model;

import javax.persistence.*;

/**
 * Table of items on a grocery list Created by Rick on 4/14/17.
 */
@Entity
@Table(name = "grocery_list_item")
public class GroceryListItem extends Identity {
	@ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
	@JoinColumn(name = "grocery_list_id", nullable = false)
	private GroceryList groceryList;

	@ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
	@JoinColumn(name = "item_id", nullable = false)
	private Item item;

	@Column(name = "quantity")
	private int quantity;

	@Column(name = "package_type")
	private String packageType;

	@Column(name = "weight")
	private int weight;

	public int getWeight() {
		return weight;
	}

	public void setWeight(int weight) {
		this.weight = weight;
	}

	public GroceryListItem() {
	}

	public GroceryList getGroceryList() {
		return groceryList;
	}

	public void setGroceryList(GroceryList groceryList) {
		this.groceryList = groceryList;
		groceryList.getGroceryListItems().add(this);
	}

	public Item getItem() {
		return item;
	}

	public void setItem(Item item) {
		this.item = item;
		item.getGroceryListItems().add(this);
	}

	public int getQuantity() {
		return quantity;
	}

	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}

	public String getPackageType() {
		return packageType;
	}

	public void setPackageType(String packageType) {
		this.packageType = packageType;
	}
}
