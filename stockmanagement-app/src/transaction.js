import React from 'react';
import { DateField ,Filter,List, Datagrid,SelectInput,SelectField , TextField,EditButton,Edit,SimpleForm,Create,DateInput,TextInput,NumberInput,ReferenceField,ReferenceInput } from 'react-admin';


const choices = [
    { id: 1, name: 'Buy' },
    { id: 2, name: 'Sell' },
 ];

export const TransactionList = (props) => (
    <List title="All Transactions" {...props} filters={<TransactionFilter />} >
        <Datagrid rowClick="edit">
            
            <ReferenceField label="Product" source="productId" reference="product">
                <TextField source="name" />
            </ReferenceField>          

            <SelectField  source="type" choices={choices} translateChoice={false}/>
            <TextField source="quantity" /> 
            <TextField source="amount" /> 
            <DateField  source="createdAt" /> 
           
        </Datagrid>
    </List>
);

export const TransactionFilter = (props) => (
    <Filter {...props}>
          <ReferenceInput label="Select Company" source="companyId" reference="company" alwaysOn >
                <SelectInput optionText="name" />
            </ReferenceInput>  
    </Filter>
);

export const TransactionEdit = props => (
    <Edit {...props}>
        <SimpleForm>
        <SelectInput source="type" choices={choices} translateChoice={false}/>
            <NumberInput source="quantity" /> 
            <NumberInput source="amount" /> 
            <ReferenceInput label="Product" source="productId" reference="product">
                <SelectInput optionText="name" />
            </ReferenceInput>  
        </SimpleForm>
    </Edit>
);


export const TransactionCreate = props => (
    <Create {...props}>
        <SimpleForm>
            <SelectInput source="type" choices={choices} translateChoice={false}/>
            <NumberInput source="quantity" /> 
            <NumberInput source="amount" /> 
            <ReferenceInput label="Product" source="productId" reference="product">
                <SelectInput optionText="name" />
            </ReferenceInput>        
        </SimpleForm>
    </Create>
);