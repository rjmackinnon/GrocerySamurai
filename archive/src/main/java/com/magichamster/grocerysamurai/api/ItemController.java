package com.magichamster.grocerysamurai.api;

import javax.ws.rs.*;
import javax.ws.rs.core.Response;

import com.magichamster.grocerysamurai.business.IBaseProcess;
import com.magichamster.grocerysamurai.model.Item;

@Path("/item/")
public class ItemController extends BaseController<Item> {

	public ItemController(IBaseProcess<Item> process) {
		super(process);
	}

	@Override
	@POST
	@Path("/add/")
	public Response add(Item item) {
		return addHelper(item);
	}

	@Override
	@PUT
	@Path("/update/")
	public Response update(Item item) {
		return updateHelper(item);
	}

	@Override
	@DELETE
	@Path("/delete/{id}")
	public Response delete(@PathParam("id") int id) {
		return deleteHelper(id);
	}

	@Override
	@GET
	@Path("/get/{id}")
	public Item get(@PathParam("id") int id) {
		return getHelper(id);
	}

}
