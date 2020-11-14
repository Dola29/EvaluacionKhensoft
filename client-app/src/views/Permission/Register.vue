<template>
    <div class="container">
        <form @submit.prevent="editMode === true ? update() : save()">
            <div class="row">
                <div class="form-group col-6">
                    <label>Employee Name</label>
                    <input v-model="permission.employeeName" type="text" name="empresa" class="form-control">
                </div>
                <div class="form-group col-6">
                    <label>Employee Last</label>
                    <input v-model="permission.employeeLastName" type="text" name="contacto" class="form-control" >
                </div>                                
            </div> 
            <div class="row">
                <div class="form-group col-6">
                    <label>Permission Type</label>
                    <select class="form-control" v-model="permission.permissionTypeId">
                        <option v-for="permision in permissionTypeOptions" :value="permision.id">{{permision.description}}</option>
                    </select>
                </div>
                <div class="form-group col-6">
                    <label>Permission Date</label>
                    <b-form-datepicker
                        id="fecha_expiracion"
                        v-model="permission.PermissionDate"
                        :date-format-options="{ year: 'numeric', month: 'numeric', day: 'numeric' }"
                        locale="es"
                        placeholder="Select A date"
                    ></b-form-datepicker>
                </div>                                
            </div> 
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Back</button>
                <button v-show="editMode" type="submit" class="btn btn-warning">Update</button>
                <button v-show="!editMode" type="submit" class="btn btn-success">Save</button>
            </div>
        </form>
    </div>
</template>

<script>
export default {
    created() {
        this.getPermissionTypes();
    },
    data() {
        return {
            permissionTypeOptions: [],
            permission:{
                employeeName: null,
                employeeLastName: null,
                permissionTypeId: null,
                PermissionDate: null
            },
            editMode: false
        }
    },
    methods: {
        getPermissionTypes(){
            axios.get(be_url+'/permissionType')
            .then(response => {
                this.permissionTypeOptions = response.data;       
            })
            .catch(errors => {
                console.log(errors);
            });
        },

        save(){
            if(!this.permission.employeeName || !this.permission.employeeLastName  || !this.permission.permissionTypeId || !this.permission.PermissionDate){
                swal.fire('Error!','All Fields are required','error');
            }else{
                axios.post(be_url+'/permission',this.permission)
                .then(()=>{
                    this.permission.employeeName = null;
                    this.permission.employeeLastName = null;
                    this.permission.permissionTypeId = null;
                    this.permission.PermissionDate = null;
                    toast.fire({
                        icon: 'success',
                        title: 'The info was Saved!!!'
                    }); 
                })
                .catch(function (error) {
                    console.log(error);
                });      
            }
        
        }

    },
}
</script>

<style>

</style>