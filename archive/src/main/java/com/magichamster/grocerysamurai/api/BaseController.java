package com.magichamster.grocerysamurai.api;

import java.util.Optional;

import javax.ws.rs.PathParam;
import javax.ws.rs.WebApplicationException;
import javax.ws.rs.core.Response;

import com.magichamster.grocerysamurai.business.IBaseProcess;
import com.magichamster.grocerysamurai.model.Identity;

public abstract class BaseController<T extends Identity> implements IBaseController<T> {
	private IBaseProcess<T> process;
	
	public BaseController(IBaseProcess<T> process) {
		this.process = process;
	}
	
	public Response addHelper(T item)	{
		try {
			process.persist(item);
			return Response.ok().build();
		}
		catch (Exception ex) {
			throw new WebApplicationException(Response.Status.INTERNAL_SERVER_ERROR);
		}
	}

	public Response updateHelper(T item)	{
		try {
			process.merge(item);
			return Response.ok().build();
		}
		catch (Exception ex) {
			throw new WebApplicationException(Response.Status.INTERNAL_SERVER_ERROR);
		}
	}
	
	public Response deleteHelper(@PathParam("id") int id)
	{
		try {
			process.remove(id);
			return Response.ok().build();
		}
		catch (Exception ex) {
			throw new WebApplicationException(Response.Status.INTERNAL_SERVER_ERROR);
		}
	}
	
	public T getHelper(@PathParam("id") int id) {
		try {
			Optional<T> result = process.get(id);
			return result.orElseThrow(WebApplicationException::new);
		}
		catch (Exception ex) {
			throw new WebApplicationException(Response.Status.INTERNAL_SERVER_ERROR);
		}
	}
}
