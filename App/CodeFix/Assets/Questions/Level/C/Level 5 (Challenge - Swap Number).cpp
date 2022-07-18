/*
	Swap Two numbers
	*a(3), *b(3), &a(3), &b(3), a(3), b(3)
*/
#include<stdio.h>
void swap(int , int ) {
	int temp = ;
	 = ;
	 = temp;
}

int main() {
	int a = 2;
	int b = 3;
	printf("Before Swap\n");
	printf("num1 : %d | num2 : %d\n", , );
	
	swap(, );
	
	printf("After Swap\n");
	printf("num1 : %d | num2 : %d\n", , );
	return 0;
}


/*
Answer

#include<stdio.h>
void swap(int *a, int *b) {
	int temp = *a;
	*a = *b;
	*b = temp;
}

int main() {
	int a = 2;
	int b = 3;
	printf("Before Swap\n");
	printf("num1 : %d | num2 : %d\n", a, b);
	
	swap(&a, &b);
	
	printf("After Swap\n");
	printf("num1 : %d | num2 : %d\n", a, b);
	return 0;
}
*/
