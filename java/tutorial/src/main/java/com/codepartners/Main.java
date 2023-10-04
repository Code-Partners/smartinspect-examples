package com.codepartners;

import com.gurock.smartinspect.InvalidConnectionsException;
import com.gurock.smartinspect.SmartInspect;
import com.gurock.smartinspect.session.Session;

import java.util.Objects;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) throws InvalidConnectionsException {
        SmartInspect smartInspect = new SmartInspect("Java tutorial example");

        smartInspect.setConnections("tcp()");

        smartInspect.setEnabled(true);

        Session session = smartInspect.addSession("tutorial", true);

        session.enterProcess("JavaTutorialExample");
        session.logMessage("Project started");

        Scanner scanner = new Scanner(System.in);
        System.out.println("Type messages to send them to SmartInspect");
        System.out.println("Type \"exit\" to close the app");
        String input;
        do {
            input = scanner.nextLine();

            session.logMessage(input);
        } while (!Objects.equals(input, "exit"));

        session.leaveProcess();

        smartInspect.dispose();
    }
}