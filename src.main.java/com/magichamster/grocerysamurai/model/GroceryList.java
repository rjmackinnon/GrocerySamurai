package com.magichamster.grocerysamurai.model;

import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;

/**
 * Table of grocery lists
 * Created by Rick on 4/14/17.
 */
@Entity
@Table(name = "grocery_list")
public class GroceryList extends Identity {
    @ManyToOne(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
    @JoinColumn(name = "store_id", nullable = false )
    private Store store;

    @Column(name = "name")
    private String name;

    @Column(name = "description")
    private String description;

    @OneToMany(fetch = FetchType.LAZY, cascade = { CascadeType.ALL,CascadeType.PERSIST,CascadeType.MERGE }, mappedBy = "groceryList")
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

    public GroceryList() {
        groceryListItems = new HashSet<>(0);
    }

    public Set<GroceryListItem> getGroceryListItems() {
        return groceryListItems;
    }

    public void setGroceryListItems(Set<GroceryListItem> groceryListItems) {
        this.groceryListItems = groceryListItems;
    }

    public Store getStore() {
        return store;
    }

    public void setStore(Store store) {
        this.store = store;
        store.getGroceryLists().add(this);
    }
}
