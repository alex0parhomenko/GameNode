from flask import Flask, request, render_template, jsonify, abort, make_response, Response
from flask import send_file
from flaskext.mysql import MySQL
import MySQLdb
from settings import *
import os
from datetime import date, datetime

app = Flask(__name__)
db = MySQLdb.connect(HOST, USER, PASSWORD, DBNAME)

@app.route(os.path.join("/", VERSION, "get_datetime"), methods=["GET"])
def get_datetime():
    now = datetime.now()
    return jsonify(day=now.day, year=now.year, month=now.month, hour=now.hour, minute=now.minute, second=now.second)

@app.route()
def

if __name__ == '__main__':
    app.debug = DEBUG
    app.run(host=HOST, port=PORT)
