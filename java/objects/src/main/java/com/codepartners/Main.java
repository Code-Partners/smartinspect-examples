package com.codepartners;

import com.gurock.smartinspect.InvalidConnectionsException;
import com.gurock.smartinspect.SmartInspect;
import com.gurock.smartinspect.session.Session;

import java.awt.*;
import java.util.Objects;
import java.util.Scanner;

/**
 *  Description:
 *
 *  This example demonstrates the usage of multiple
 *  session objects with one SmartInspect object.
 *  Each session object is assigned a different
 *  session name and color for easier identification
 *  and filtering in the SmartInspect console.
 */
public class Main {
    public static void main(String[] args) throws InvalidConnectionsException, InterruptedException {
        SmartInspect smartInspect = new SmartInspect("Java objects example");
        Session blue = smartInspect.addSession("Blue");
        Session green = smartInspect.addSession("Green");

        smartInspect.setConnections("tcp()");
        smartInspect.setEnabled(true);

        // Set the session colors
        blue.setColor(Color.BLUE);
        green.setColor(Color.GREEN);

        // Log the messages
        blue.logMessage("This message is blue!");
        green.logMessage("This message is green!");

        Thread.sleep(1000);

        smartInspect.dispose();
    }
}