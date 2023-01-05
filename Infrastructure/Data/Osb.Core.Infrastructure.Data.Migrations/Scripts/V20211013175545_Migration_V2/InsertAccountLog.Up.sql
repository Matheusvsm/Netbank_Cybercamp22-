CREATE OR REPLACE FUNCTION public.insertaccountlog(
	"paramLogin" character varying)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."AccountLog"
                    (
	                 "Login",
					 "LogDate",
					 "CreationDate",
				     "CreationUserId",
					 "UserId")
	VALUES (
           "paramLogin",
		   CURRENT_DATE,
           CURRENT_DATE,
           '1',
		   '1')
$BODY$;

ALTER FUNCTION public.insertaccountlog(character varying)
    OWNER TO "OSB";
