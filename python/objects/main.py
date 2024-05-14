from smartinspect.common.color import Color
from smartinspect import SmartInspect

# Description:
#
# This example demonstrates the usage of multiple
# session objects with one SmartInspect object.
# Each session object is assigned a different
# session name and color for easier identification
# and filtering in the SmartInspect console.

if __name__ == "__main__":
    # create a SamrtInspect instance and add two Session objects
    si = SmartInspect("Python objects example")
    blue = si.add_session("Blue")
    green = si.add_session("Green")

    # supply a connection string and enable SmartInspect
    si.set_connections("tcp()")
    si.set_enabled(True)

    # assign each session a color
    blue.color = Color.BLUE
    green.color = Color.GREEN

    # log the messages
    blue.log_message("This message is blue!")
    green.log_message("This message is green!")

    si.dispose()
