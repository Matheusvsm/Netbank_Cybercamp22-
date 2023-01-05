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
    "UserId",
    "AccountId",
    "PixKeyValue",
    "PixKeyType",
    "Status",
    "CreationDate",
    "UpdateDate",
    "DeletionDate",
    "CreationUserId",
    "UpdateUserId"
)
VALUES
(
    "paramUserId",
    "paramAccountId",
    "paramPixKey",
    "paramPixKeyType",
    "paramStatus",
    now(),
    now(),
    null,
    "paramUserId",
    "paramUserId"
)
RETURNING "PixKeyId"
$BODY$;

ALTER FUNCTION public.insertpixkey(integer, character varying, bigint, bigint, integer)
    OWNER TO "OSB";