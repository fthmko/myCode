CREATE TABLE "message" (
"lang"  TEXT(4) NOT NULL,
"version"  TEXT(10) NOT NULL,
"translator"  TEXT(20),
"encode"  TEXT(20),
"xmlns"  TEXT,
PRIMARY KEY ("lang" ASC, "version" ASC)
);

CREATE TABLE "tag" (
"key"  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
"seq"  INTEGER NOT NULL DEFAULT 0,
"tagname"  TEXT NOT NULL,
"propname"  TEXT,
"propvalue"  TEXT,
"textvalue"  TEXT,
"parent"  INTEGER NOT NULL DEFAULT -1,
"msgkey"  TEXT
);

