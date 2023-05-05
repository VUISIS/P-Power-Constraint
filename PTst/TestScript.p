test tc [main=Test]:
  assert AlwaysCorrect in
  (union Ping, Pong, { Test });
