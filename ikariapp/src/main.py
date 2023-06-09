#!/usr/bin/env python
#
# Copyright 2007 Google Inc.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#     http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.

import webapp2

from controllers.WikiLoginHandler import WikiLoginHandler
from controllers.WikiSignupHandler import WikiSignupHandler
from controllers.WikiLogoutHandler import WikiLogoutHandler
from controllers.WikiEditHandler import WikiEditHandler
from controllers.WikiHandler import WikiHandler
from controllers.WikiHistoryHandler import WikiHistoryHandler

PAGE_RE = r'(/(?:[a-zA-Z0-9_-]+/?)*)'
app = webapp2.WSGIApplication([('/wiki/signup', WikiSignupHandler),
                               ('/wiki/login', WikiLoginHandler),
                               ('/wiki/logout', WikiLogoutHandler),
                               ('/wiki/_edit' + PAGE_RE, WikiEditHandler),
                               ('/wiki/_history' + PAGE_RE, WikiHistoryHandler),
                               ('/wiki' + PAGE_RE, WikiHandler)],
                              debug=True)
