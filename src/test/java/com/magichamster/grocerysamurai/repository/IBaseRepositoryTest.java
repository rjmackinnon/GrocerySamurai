package com.magichamster.grocerysamurai.repository;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.*;

/**
 * Created by rick on 4/14/17.
 */
public abstract class IBaseRepositoryTest {
    private static long startTime;

    @Before
    public void setUp() throws Exception {
        startTime = System.currentTimeMillis();
    }

    @After
    public void tearDown() throws Exception {
        final long endTime = System.currentTimeMillis();
        final long diff = endTime - startTime;

        System.out.println("Millis spent: " + diff);
    }

    @Test
    public void persist() throws Exception {
    }

    @Test
    public void persist1() throws Exception {
    }

    @Test
    public void persist2() throws Exception {
    }

    @Test
    public void remove() throws Exception {
    }

    @Test
    public void remove1() throws Exception {
    }

    @Test
    public void remove2() throws Exception {
    }

    @Test
    public void remove3() throws Exception {
    }

    @Test
    public void remove4() throws Exception {
    }

    @Test
    public void get() throws Exception {
    }

    @Test
    public void get1() throws Exception {
    }

    @Test
    public void get2() throws Exception {
    }

}