package com.magichamster.grocerysamurai.model;

import javax.persistence.*;
import java.util.Objects;

/**
 * Abstract class for database classes Created by Rick on 4/13/17.
 */
@MappedSuperclass
public abstract class Identity {
	@Id
	@Column(name = "id", updatable = false, nullable = false)
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;

	public int getId() {
		return id;
	}

	@Override
	public boolean equals(Object o) {
		if (this == o)
			return true;
		if (o == null || getClass() != o.getClass())
			return false;
		Identity identity = (Identity) o;
		return Objects.equals(id, identity.id);
	}

	@Override
	public int hashCode() {
		return Objects.hash(id);
	}

	@Override
	public String toString() {
		return this.getClass().getSimpleName() + "[id=" + String.format("%d", id) + "...]";
	}
}
