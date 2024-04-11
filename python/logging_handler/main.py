import logging
from common.color.color import Color
from smartinspect_handler.smartinspect_handler import SmartInspectHandler

# Description:
#
# This example demonstrates the usage of SmartInspectHandler to dispatch log messages from logging Logger
# as well as from the underlying SmartInspect instance.


if __name__ == "__main__":
    # summon a logging Logger
    logger = logging.getLogger(__name__)

    # instantiate SmartInspectHandler, set format and add handler to the Logger instance
    handler = SmartInspectHandler("Client app", "tcp()")
    handler.setFormatter(logging.Formatter("%(threadName)s, %(asctime)s: %(module)s @ %(funcName)s: %(message)s"))
    logger.addHandler(handler)
    logger.setLevel(logging.DEBUG)

    logger.debug("Message")

    # You can use the underlying SmartInspect instance as well
    si = handler.get_si()
    session = si.add_session("Before", True)
    session.log_colored(Color.BLUE, "Logging from SI")
