package com.codepartners;

import com.gurock.smartinspect.InvalidConnectionsException;
import com.gurock.smartinspect.SmartInspect;
import com.gurock.smartinspect.connections.builder.cloud.CloudConnectionStringBuilder;
import com.gurock.smartinspect.session.Session;

import java.util.Objects;
import java.util.Scanner;

public class Main {
    private static final String WRITE_KEY = "INSERT_WRITE_KEY_HERE";

    public static void main(String[] args) throws InvalidConnectionsException {
        SmartInspect smartInspect = new SmartInspect("Java cloud example");

        smartInspect.setConnections(
                (new CloudConnectionStringBuilder())
                        .addCloudProtocol()
                        .setRegion("eu-central-1")
                        .setWriteKey(WRITE_KEY)
                        .addCustomLabel("User", "Bob")
                        .addCustomLabel("Version", "0.0.1")
                        .and().build()
        );

        smartInspect.setEnabled(true);

        Session session = smartInspect.addSession("cloud", true);

        session.enterProcess("JavaCloudExample");
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