'''
Created on 02.05.2012

@author: Ikari
'''
from google.appengine.ext import db

class Art(db.Model):
    title = db.StringProperty(required = True)
    art = db.TextProperty(required = True)
    created = db.DateTimeProperty(auto_now_add = True)