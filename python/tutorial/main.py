from smartinspect import SmartInspect

# Description:
#
# This example demonstrates the basic usage of SmartInspect.


if __name__ == "__main__":
    # create a SamrtInspect instance
    si = SmartInspect("Python tutorial example")

    # supply a connection string and enable SmartInspect
    si.set_connections("tcp()")
    si.set_enabled(True)

    # add a seesion and log messages
    session = si.add_session("Tutorial", True)
    session.enter_process("PythonTutorialExample")
    session.log_message("Project started")

    print("Type messages to send them to SmartInspect")
    print("Type \"exit\" to close the app")
    msg = input("Message:")

    while msg != "exit":
        session.log_message(msg)
        msg = input("Message:")

    session.leave_process()

    si.dispose()
