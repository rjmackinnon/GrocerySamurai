package com.magichamster.grocerysamurai.business;

import java.util.Optional;

import javax.persistence.Persistence;

import com.magichamster.grocerysamurai.model.Login;
import com.magichamster.grocerysamurai.model.AppUser;
import com.magichamster.grocerysamurai.repository.BaseRepository;
import com.magichamster.grocerysamurai.repository.IBaseRepository;

public class UserProcess extends BaseProcess<AppUser> {
	public UserProcess(IBaseRepository<AppUser> repository) {
		super(repository == null ? new BaseRepository<AppUser>(AppUser.class, Persistence.createEntityManagerFactory("grocery")) :
			repository);
	}

	public void register(AppUser user)
	{
		
	}
	
	public Optional<AppUser> validateUser(Login login)
	{
		return repository.get().stream().findFirst();
	}
}
