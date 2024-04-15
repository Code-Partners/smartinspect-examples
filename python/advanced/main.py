import datetime
import sqlite3
import threading
import time
from fractions import Fraction

from smartinspect.common.color import Color
from smartinspect.common.level import Level
from smartinspect.common.context import ViewerContext
from smartinspect.common.viewer_id import ViewerId
from smartinspect.packets import LogEntryType, ProcessFlowType, WatchType
from smartinspect.common.source_id import SourceId
from smartinspect import SmartInspect


# Description:
#
# This example demonstrates advanced usage of SmartInspect by exposing variety of methods.


class DummyFather:
    __parent_class_private = 0
    _parent_class_protected = 1
    parent_class_public = 2

    def __init__(self):
        self.__derived_private = 0
        self._derived_protected = 0
        self.derived_public = 0

    def do_something(self):
        pass


class Dummy(DummyFather):
    __class_private = 3
    _class_protected = 4
    class_public = 5

    def __init__(self):
        super().__init__()
        self.__instance_private = 6
        self._instance_protected = 7
        self.instance_public = 8

    def do_something(self):
        pass

    def do_another_thing(self):
        pass

    def __repr__(self):
        return self.__class__.__name__


dummy = Dummy()

if __name__ == '__main__':

    si = SmartInspect('Python Client')
    si.set_connections("tcp()")
    si.set_enabled(True)
    session = si.add_session("Session name", True)
    session.clear_all()

    session.enter_process("Enter process {}", "name")
    session.log_separator()
    session.reset_call_stack()
    session.enter_method("Called method with {kwarg}, arg {} and {}", "arg1", 2, instance=dummy, kwarg="kwargs")
    session.leave_method("Leaving method with {} and arg {}", "arg1", 2, instance=dummy)
    session.reset_call_stack()
    session.enter_thread("Entering thread with {} and arg {}", "arg1", 2)
    session.leave_thread("Leaving thread with {} and arg {}", "arg1", 2)
    session.leave_process("Leave process {}", "name")

    session.enter_process("Enter another process {}", "name")
    session.enter_thread("Entering thread with {} and arg {}", "arg1", 2)

    session.log_colored(Color.BLACK, "Text with {}", "args")

    session.level = Level.DEBUG
    session.log_debug("Logging {}", "debug")
    session.level = Level.VERBOSE
    session.log_verbose("Logging {}", "verbose")
    session.level = Level.MESSAGE
    session.log_message("Logging {}", "message")
    session.level = Level.WARNING
    session.log_warning("Logging {}", "warning")
    session.level = Level.ERROR
    session.log_error("Logging {}", "error")
    session.level = Level.FATAL
    session.log_fatal("Logging {}", "fatal")

    session.level = Level.MESSAGE
    session.add_checkpoint("Checkpoint", "initiating checkpoint")
    session.add_checkpoint("Checkpoint", "incrementing")
    session.add_checkpoint("Checkpoint", "incrementing")
    session.reset_checkpoint("Checkpoint")
    session.add_checkpoint("Checkpoint", "after reset")

    a, b = 1, 2
    session.log_assert(a > b, "{} > {} is {}", a, b, a > b)

    session.log_is_none("Am I None", None)
    session.log_conditional(a > b, "Log {} > {}", a, b)
    session.log_conditional(a < b, "Log {} < {}", a, b)

    session.log_separator()
    session.log_bool("Bool", True)
    session.log_str("Str", "string")
    session.log_bytes("Byte with hex", b"string123456", include_hex=True)
    session.log_bytes("Byte without hex", b"string123456")
    session.log_bytearray("Bytearray with hex", bytearray(b"string123456"), include_hex=True)
    session.log_bytearray("Bytearray without hex", bytearray(b"string123456"))
    session.log_int("Int with hex", 123456, include_hex=True)
    session.log_int("Int without hex", 123456)
    session.log_float("Float", 3.123456)
    session.log_object_value("Object", dummy)
    session.log_time("Time", datetime.time(12, 30, 31))
    session.log_datetime("DateTime", datetime.datetime(2023, 2, 23, 12, 30, 31))
    session.log_list("List", [1, 2, 3, 4, 5, 6])
    session.log_tuple("Tuple", (1, 2, 3, 4, 5, 6))
    session.log_set("Set", {1, 2, 3, 4, 5, 6})
    session.log_dict_value("Dict", {1: True, 4: "5.6", 7: 8.9, 10: dummy})
    session.log_complex("Complex", complex(3, 2))
    session.log_fraction("Fraction", Fraction(1, 3))
    session.log("Fraction again", Fraction(1, 3))

    context = ViewerContext(ViewerId.INSPECTOR)
    session.log_custom_context("Custom Context", LogEntryType.WARNING, context)

    session.log_custom_text("Custom Text", "is custom text", LogEntryType.MEMORY_STATISTIC, ViewerId.DATA)
    session.log_custom_file("just.txt", LogEntryType.DEBUG, ViewerId.DATA, "just a file")
    session.log_text("Logging text", "text")
    session.log_text_file("just.txt", "Logging text file")
    session.log_html("Html code", "<b>Ht</b>ml")
    session.log_html_file("just.html", "Html file")
    session.log_binary("Binary", b"binary", 3)
    session.log_binary_file("just.txt", "File")

    session.log_ico_file("icon.ico")
    session.log_sql("SQL statement", "SELECT name, age FROM users WHERE age = 1")
    session.log_source("Python source", "def python_me():\n\tpass", SourceId.PYTHON)
    session.log_source("Javascript source", "function JS_me(p1, p2) {\n\treturn p1 * p2;\n}", SourceId.JAVASCRIPT)
    session.log_object("Dummy object without private fields", dummy)
    session.log_object("Dummy object with private fields", dummy, include_non_public_fields=True)
    session.log_exception(ValueError("I am ValueError"), "ValueError")
    session.log_current_thread("Current thread")

    another_thread = threading.Thread(target=time.sleep, args=(.5,))
    another_thread.start()
    session.log_thread("Another thread", another_thread)

    iterables = [[1, dummy, [1, 2, 3]],
                 (1, 2, 3),
                 {1, 2, 3},
                 {1: True, 3: "Four", 5: None},

                 ]
    for terrible in iterables:
        session.log_iterable(terrible, "Iterable")
    lst = [1, 2, 3]
    lst.append(lst)
    lst.append(5)
    session.log_iterable(lst, "Iterable with cycle")

    dic = {1: True, 3: dummy, 5: None}
    dic[6] = dic
    session.log_dict(dic, "Dictionary with cycle")
    session.log_current_stacktrace()
    session.log_system()

    conn = sqlite3.connect('example.db')
    cursor = conn.cursor()
    cursor.execute('SELECT * FROM users')
    session.log_cursor_data(cursor, "Cursor data")
    session.log_cursor_metadata(cursor, "Cursor metadata")
    session.log_string("String", "Stringy string")

    for _ in range(4):
        session.inc_counter("Counter")
        time.sleep(.5)
    session.reset_counter("Counter")
    for _ in range(4):
        session.inc_counter("Counter")
        time.sleep(.5)
    for _ in range(8):
        session.dec_counter("Counter")
        time.sleep(.5)

    session.send_custom_log_entry("Custom LogEntry", LogEntryType.WARNING, ViewerId.DATA, b"Some data")
    session.send_custom_watch("Custom Watch", str(42), WatchType.INT)
    session.send_custom_process_flow("Custom Process Flow", ProcessFlowType.ENTER_PROCESS)
    session.watch("Str", "str")
    session.watch("Int", 1)
    session.watch("Object", dummy)

    si.dispose()
