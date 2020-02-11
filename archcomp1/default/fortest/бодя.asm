segst	segment para stack  'stack'
	db	64 dup('stack   ')
segst	ends
dseg segment 'data'
p1 DB 023AH
p2 DW 3,15,-7,23
p3 DB 'ohnonono'
p4 DB ?
p5 DW 3 dup(14,2,-7) 
p6 DW 2H,-10H,21CH,0BH
dseg ends
cseg segment
  assume ds:dseg,cs:cseg,ss:segst
main proc far
   push ds
   sub AX,AX
   push AX
   mov AL,-31
   mov AX,274
   mov BX,offset p3
   mov offset p2,offset p4
   mov BH,offset p5
   mov DS,offset p1
   ret
main endp
cseg ends
end main