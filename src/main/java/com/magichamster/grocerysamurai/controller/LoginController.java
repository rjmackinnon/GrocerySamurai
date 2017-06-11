package com.magichamster.grocerysamurai.controller;

import java.util.Optional;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;

import com.magichamster.grocerysamurai.business.UserProcess;
import com.magichamster.grocerysamurai.model.Login;
import com.magichamster.grocerysamurai.model.AppUser;

@Controller
public class LoginController {
	UserProcess userProcess;
	
	@RequestMapping(value = "/login", method = RequestMethod.GET)
	public ModelAndView showLogin() {
		ModelAndView mav = new ModelAndView("login");
		mav.addObject("login", new Login());
		return mav;
	}
	
	@RequestMapping(value = "/login", method = RequestMethod.POST)
	public ModelAndView loginProcess(@ModelAttribute("login") Login login) {
		userProcess = new UserProcess(null);
		ModelAndView mav = null;
		Optional<AppUser> user = userProcess.validateUser(login);
		if (user.isPresent()) {
			mav = new ModelAndView("welcome");
			mav.addObject("firstname", user.get().getFirstname());
		} else {
			mav = new ModelAndView("login");
			mav.addObject("message", "Invalid username or password.");
		}
		return mav;
	}
}
