from smartinspect.connections import ConnectionStringBuilder
from smartinspect import SmartInspect

# Description:
#
# This example demonstrates the usage of SmartInspect with the Cloud.
# You can use a ConnectionStringBuilder instance to build a connection string.
# You will need a write key to log to the Cloud.


WRITE_KEY = "INSERT_WRITE_KEY_HERE"

if __name__ == "__main__":

    si = SmartInspect("Python cloud example")

    conn_string = ConnectionStringBuilder().add_cloud_protocol() \
        .set_region("eu-central-1") \
        .set_write_key(WRITE_KEY) \
        .add_custom_label("User", "Bob") \
        .add_custom_label("Version", "0.0.1") \
        .end_protocol().build()

    si.set_connections(conn_string)
    si.set_enabled(True)

    session = si.add_session("cloud", True)
    session.enter_process("PythonCloudExample")
    session.log_message("Project started")

    print("Type messages to send them to SmartInspect")
    print("Type \"exit\" to close the app")
    msg = input("Message:")

    while msg != "exit":
        session.log_message(msg)
        msg = input("Message:")

    session.leave_process()

    si.dispose()
