#import <stdio.h>

void main(void){
    
    int array[10];

    for(int i = 0; i < 10; i++)
    {
         printf("Ingrese el numero %d\t", i+1);
         scanf("%d", &array[i]);	
    }

    int smallestNumber = array[0];
    int biggestNumber = array[0] ;

    for(int i = 0; i < 10; i++)
    {
        if(array[i]>biggestNumber) {biggestNumber = array[i];}
        if(array[i]<smallestNumber) {smallestNumber = array[i];}
    }

    printf("El numero mas grande es %d\t\n", biggestNumber);
    printf("El numero mas chico es %d\t\n", smallestNumber);
}