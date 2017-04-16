package com.magichamster.grocerysamurai.model;

import javax.persistence.*;

/**
 * Table of grocery items
 * Created by rick on 4/9/17.
 */
@Entity
@Table(name = "item")
public class Item extends Identity {
    @Id
    @Column(name = "id")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @Column(name = "name")
    private String name;

    @Column(name = "description")
    private String description;

    @Column(name = "upc")
    private long Upc;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

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

    public Item(){
    }
}
