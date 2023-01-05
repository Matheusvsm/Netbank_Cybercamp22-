CREATE OR REPLACE FUNCTION public.insertinputlog(
	"paramRequest" text
    )
    RETURNS void
    LANGUAGE 'sql'
    COST 100
    VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."InputLog" (
	"Request",
	"CreationDate",
    "UpdateDate",
    "CreationUserId",
    "UpdateUserId"
    )
VALUES (        		 
   "paramRequest",
	Now(),
    Now(),
    1,
    1
    )
$BODY$;

ALTER FUNCTION public.insertinputlog(text)
    OWNER TO "OSB";