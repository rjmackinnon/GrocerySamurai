package com.magichamster.grocerysamurai.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;

import com.magichamster.grocerysamurai.business.UserProcess;
import com.magichamster.grocerysamurai.model.AppUser;

import org.springframework.ui.ModelMap;

/**
 * Register controller Created by Rick on 6/11/17.
 */
@Controller
public class RegisterController {
	public UserProcess userProcess;
	
	@RequestMapping(value = "/register", method = RequestMethod.GET)
	public ModelAndView showRegister() {
		ModelAndView mav = new ModelAndView("register");
		mav.addObject("user", new AppUser());
		return mav;
	}
	
	@RequestMapping(value = "/registerProcess", method = RequestMethod.POST)
	public ModelAndView addUser(@ModelAttribute("user") AppUser user) {
		userProcess.register(user);
		return new ModelAndView("welcome", "firstname", user.getFirstname());
	}
}
