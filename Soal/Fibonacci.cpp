#include<stdio.h>
/*
	Fibonacci
	val -> 1 1 1 2 3 5 8 13 21 34
	n   -> 0 1 2 3 4 5 6 7  8  9
	
	<=(2), +(2), -(2), >=(2), <(2), >(2)
*/

int fibo(int n) {
	if(n 2)
		return 1;
	return fibo(n 1) fibo(n 2);
}
		
int main() {
	printf("fibo(%d) = %d\n", 0, fibo(0));
	printf("fibo(%d) = %d\n", 3, fibo(3));
	printf("fibo(%d) = %d\n", 7, fibo(7));
	printf("fibo(%d) = %d\n", 9, fibo(9));
	return 0;
}

/*
Answer

#include<stdio.h>
int fibo(int n) {
	if(n <= 2)
		return 1;
	return fibo(n - 1) + fibo(n - 2);
}
		
int main() {
	printf("fibo(%d) = %d\n", 0, fibo(0));
	printf("fibo(%d) = %d\n", 3, fibo(3));
	printf("fibo(%d) = %d\n", 7, fibo(7));
	printf("fibo(%d) = %d\n", 9, fibo(9));
	return 0;
}
*/
