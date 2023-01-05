

CREATE OR REPLACE FUNCTION public.insertusercredentiallog(
	"paramLogin" character varying,
	"paramLogDate" timestamp without time zone, 
	"paramCreationDate" timestamp without time zone,
	"paramCreationUserId" bigint,
	"paramUserId" bigint)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."UserCredentialLog"
                    (
	                 "Login",
					 "LogDate",
					 "CreationDate",
				     "CreationUserId",
					 "UserId")
	VALUES (
           "paramLogin",
		   "paramLogDate",
           "paramCreationDate",
           "paramCreationUserId",
		   "paramUserId")
$BODY$;

ALTER FUNCTION public.insertusercredentiallog(character varying, timestamp without time zone, timestamp without time zone, bigint, bigint)
    OWNER TO "OSB";
