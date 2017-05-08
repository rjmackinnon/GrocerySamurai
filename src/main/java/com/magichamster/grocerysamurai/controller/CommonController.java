package com.magichamster.grocerysamurai.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;

/**
 * Basic controller Created by rick on 4/29/17.
 */
@Controller
public class CommonController {
	@RequestMapping("/welcome")
	public ModelAndView helloWorld() {

		String message = "<br><div style='text-align:center;'>"
				+ "<h3>Hello, I am dog</h3>This message is coming from controller</div><br><br>";
		return new ModelAndView("welcome", "message", message);
	}
}
