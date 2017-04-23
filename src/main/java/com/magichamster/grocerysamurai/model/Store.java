package com.magichamster.grocerysamurai.model;

import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;

/**
 * Table of stores
 * Created by Rick on 4/14/17.
 */
@Entity
@Table(name = "store")
public class Store extends Identity {
    @Column(name = "name")
    private String name;

    @Column(name = "description")
    private String description;

    @OneToMany(fetch = FetchType.LAZY, cascade = { CascadeType.ALL,CascadeType.PERSIST,CascadeType.MERGE }, mappedBy = "store")
    private Set<StoreItem> storeItems;

    @OneToMany(fetch = FetchType.LAZY, cascade = { CascadeType.ALL,CascadeType.PERSIST,CascadeType.MERGE }, mappedBy = "store")
    private Set<GroceryList> groceryLists;

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

    public Store() {
        storeItems = new HashSet<>(0);
        groceryLists = new HashSet<>(0);
    }

    public Set<StoreItem> getStoreItems() {
        return storeItems;
    }

    public void setStoreItems(Set<StoreItem> storeItems) {
        this.storeItems = storeItems;
    }

    public Set<GroceryList> getGroceryLists() {
        return groceryLists;
    }

    public void setGroceryLists(Set<GroceryList> groceryLists) {
        this.groceryLists = groceryLists;
    }
}
