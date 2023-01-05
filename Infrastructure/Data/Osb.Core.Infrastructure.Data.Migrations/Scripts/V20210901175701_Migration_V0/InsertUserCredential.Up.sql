CREATE OR REPLACE FUNCTION public.insertusercredential(
	"paramUserId" bigint,
	"paramPassword" character varying,
	"paramSalt" character varying)
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."UserCredential"(
					"UserId",
					"Password",
					"Salt",										
					"CreationDate",
					"UpdateDate",
					"CreationUserId",
					"UpdateUserId")
			VALUES ( 
					"paramUserId",	
					"paramPassword", 
					"paramSalt",					
					now(), 
					now(),
					"paramUserId",
					"paramUserId");
$BODY$;

ALTER FUNCTION public.insertusercredential(bigint, character varying, character varying)
    OWNER TO "OSB";
