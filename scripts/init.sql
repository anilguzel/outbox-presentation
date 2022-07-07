-- ALTER USER $POSTGRES_USER WITH PASSWORD '$POSTGRES_PASSWORD';
  CREATE DATABASE test;
  GRANT ALL PRIVILEGES ON DATABASE test TO postgres;
  \c test;
    CREATE TABLE IF NOT EXISTS events (
	  id int NOT NULL,
	  data text NOT NULL
	);

  CREATE TABLE IF NOT EXISTS users (
    id int NOT NULL,
	  firstname text NULL,
	  lastname text NULL,
	  isapproved boolean NOT NULL
	);