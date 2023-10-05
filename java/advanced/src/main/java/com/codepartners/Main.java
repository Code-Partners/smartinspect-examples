package com.codepartners;

import com.gurock.smartinspect.InvalidConnectionsException;
import com.gurock.smartinspect.SmartInspect;
import com.gurock.smartinspect.session.Session;

public class Main {
    public static void main(String[] args) throws InvalidConnectionsException, InterruptedException {
        SmartInspect smartInspect = new SmartInspect("Java advanced example");
        smartInspect.setConnections("tcp()");
        smartInspect.setEnabled(true);

        Session session = smartInspect.addSession("advanced", true);
        session.enterProcess("JavaAdvancedExample");

        session.logMessage("Sample log message");
        session.logWarning("Sample warning");
        session.logError("Sample error");

        session.enterMethod("Sample method");
        session.addCheckpoint("Sample checkpoint");
        session.logSeparator();
        session.logException(new RuntimeException("Sample exception"));
        session.leaveMethod("Sample method");

        session.watch("Sample integer watch", 123);
        session.watch("Sample string watch", "String watch value");

        session.logBinary("Sample binary payload", new byte[]{10});

        session.logSystem();
        session.logMemoryStatistic();

        session.leaveProcess();
        Thread.sleep(1000);
        smartInspect.dispose();
    }
}