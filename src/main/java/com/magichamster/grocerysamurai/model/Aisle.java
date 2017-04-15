package com.magichamster.grocerysamurai.model;

import javax.persistence.*;

/**
 * Table of aisles
 * Created by Rick on 4/14/17.
 */
@Entity
@Table(name = "aisle")
public class Aisle extends Identity {
    @Id
    @Column(name = "id")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @Column(name = "name")
    private String name;

    @Column(name = "description")
    private String description;

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

    Aisle() {
    }
}
