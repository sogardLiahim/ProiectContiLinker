#ifndef __MOT_QUASAR2E_H
#define __MOT_QUASAR2E_H
#define VARIABLE_PARAMETER_START 0x00020000
#define VAR_PARM_SIZE 0x0080000
#if (VARIABLE_PARAMETER_START != 0)
PARAMETER_SECTION : org = VARIABLE_PARAMETER_START   len = (VAR_PARM_SIZE )
#   endif
#endif /* __MOT_QUASAR2E_H */