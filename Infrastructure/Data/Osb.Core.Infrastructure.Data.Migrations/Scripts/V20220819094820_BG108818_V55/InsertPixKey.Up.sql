DROP FUNCTION public.insertpixkey(integer, character varying, bigint, bigint, integer);
 
CREATE OR REPLACE FUNCTION public.insertpixkey(
    "paramPixKeyType" integer,
    "paramPixKey" character varying,
	"paramUserId" bigint,
	"paramAccountId" bigint,
    "paramStatus" integer
)
RETURNS TABLE("PixKeyId" bigint)
LANGUAGE 'sql'
  COST 100
  VOLATILE PARALLEL UNSAFE
AS $BODY$
INSERT INTO public."PixKey"
(    
    "AccountId",
    "PixKeyValue",
    "PixKeyType",
    "Status",
    "CreationDate",
    "UpdateDate",    
    "CreationUserId",
    "UpdateUserId"
)
VALUES
(    
    "paramAccountId",
    "paramPixKey",
    "paramPixKeyType",
    "paramStatus",
    now(),
    now(),    
    "paramUserId",
    "paramUserId"
)
RETURNING "PixKeyId"
$BODY$;

ALTER FUNCTION public.insertpixkey(integer, character varying, bigint, bigint, integer)
    OWNER TO "OSB";