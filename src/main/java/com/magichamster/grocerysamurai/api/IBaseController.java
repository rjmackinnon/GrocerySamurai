package com.magichamster.grocerysamurai.api;

import javax.ws.rs.*;
import javax.ws.rs.core.Response;

import com.magichamster.grocerysamurai.model.Identity;

public interface IBaseController<T extends Identity> {
	@POST
	Response add(T item);
	
	@PUT
	Response update(T item);
	
	@DELETE
	Response delete(@PathParam("id") int id);
	
	@GET
	T get(@PathParam("id") int id);
}
